using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CentralCel.Datos
{
    public static class SeguridadHelper
    {
        private const int IteracionesPbkdf2 = 100_000;
        private const int TamanoSaltBytes = 16;
        private const int TamanoHashBytes = 32;
        private const int TamanoIvBytes = 16;

        // NOTA: No olvidarme mover estas claves a App.config en variables de entorno
        private const string ClaveMaestraAes = "alan_superadmin_AES_Clave_2026!";
        private const string ClaveMaestraHmac = "alan_superadmin_HMAC_Clave_2026!";

        private static byte[] ObtenerClaveAes32Bytes()
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(ClaveMaestraAes));
            }
        }

        private static byte[] ObtenerClaveHmac32Bytes()
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(ClaveMaestraHmac));
            }
        }

        public static void HashearPassword(string password, out byte[] claveHash, out byte[] claveSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(password));

            claveSalt = new byte[TamanoSaltBytes];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(claveSalt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, claveSalt, IteracionesPbkdf2, HashAlgorithmName.SHA256))
            {
                claveHash = pbkdf2.GetBytes(TamanoHashBytes);
            }
        }

        public static bool VerificarPassword(string passwordIngresada, byte[] claveHashGuardada, byte[] claveSaltGuardada)
        {
            if (string.IsNullOrEmpty(passwordIngresada) || claveHashGuardada == null || claveSaltGuardada == null)
                return false;

            if (claveHashGuardada.Length == 0 || claveSaltGuardada.Length == 0)
                return false;

            byte[] hashCalculado;
            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordIngresada, claveSaltGuardada, IteracionesPbkdf2, HashAlgorithmName.SHA256))
            {
                hashCalculado = pbkdf2.GetBytes(claveHashGuardada.Length);
            }

            return ComparacionTiempoConstante(hashCalculado, claveHashGuardada);
        }

        public static byte[] CifrarTexto(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano))
                return null;

            byte[] plainBytes = Encoding.UTF8.GetBytes(textoPlano);

            using (var aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Key = ObtenerClaveAes32Bytes();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.GenerateIV();

                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (var encryptor = aes.CreateEncryptor())
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                    }

                    return ms.ToArray();
                }
            }
        }

        public static string DescifrarTexto(byte[] datosCifrados)
        {
            if (datosCifrados == null || datosCifrados.Length <= TamanoIvBytes)
                return string.Empty;

            using (var aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Key = ObtenerClaveAes32Bytes();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] iv = new byte[TamanoIvBytes];
                Buffer.BlockCopy(datosCifrados, 0, iv, 0, TamanoIvBytes);
                aes.IV = iv;

                int cipherLength = datosCifrados.Length - TamanoIvBytes;

                using (var ms = new MemoryStream(datosCifrados, TamanoIvBytes, cipherLength))
                using (var decryptor = aes.CreateDecryptor())
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs, Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        
        public static byte[] CalcularBlindIndex(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return null;

            string normalizado = valor.Trim().ToUpperInvariant();
            byte[] key = ObtenerClaveHmac32Bytes();

            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(normalizado));
            }
        }

        
        public static void InicializarSuperAdminSiNoExiste(SqlConnection conn)
        {
            if (conn == null)
                throw new ArgumentNullException(nameof(conn));

            const string sqlContar = "SELECT COUNT(1) FROM dbo.Usuarios;";
            const string sqlInsertar = @"
                INSERT INTO dbo.Usuarios (NombreUsuario, CICifrado, CIHash, Nombres, Apellidos, DireccionCifrada, TelefonoCifrado, CorreoCifrado, Fecha_nacimiento,
                    ClaveHash, ClaveSalt, IdRol, IdSucursal, IdSueldo, Activo
                )
                VALUES (
                    @NombreUsuario,
                    @CICifrado,
                    @CIHash,
                    @Nombres,
                    @Apellidos,
                    @DireccionCifrada,
                    @TelefonoCifrado,
                    @CorreoCifrado,
                    @FechaNacimiento,
                    @ClaveHash,
                    @ClaveSalt,
                    @IdRol,
                    @IdSucursal,
                    @IdSueldo,
                    1
                );";

            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (var cmdCount = new SqlCommand(sqlContar, conn))
            {
                int totalUsuarios = Convert.ToInt32(cmdCount.ExecuteScalar());
                if (totalUsuarios > 0)
                    return;
            }

            HashearPassword("Superadmin2026!", out byte[] claveHash, out byte[] claveSalt);

            byte[] ciCifrado = CifrarTexto("12668086");
            byte[] ciHash = CalcularBlindIndex("12668086");
            byte[] direccionCifrada = CifrarTexto("La Paz");
            byte[] telefonoCifrado = CifrarTexto("78781713");
            byte[] correoCifrado = CifrarTexto("alan@centralcel.com");

            using (var cmdInsert = new SqlCommand(sqlInsertar, conn))
            {
                cmdInsert.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar, 50).Value = "alan_superadmin";
                cmdInsert.Parameters.Add("@CICifrado", SqlDbType.VarBinary, -1).Value = (object)ciCifrado ?? DBNull.Value;
                cmdInsert.Parameters.Add("@CIHash", SqlDbType.VarBinary, 32).Value = (object)ciHash ?? DBNull.Value;
                cmdInsert.Parameters.Add("@Nombres", SqlDbType.NVarChar, 100).Value = "Alan";
                cmdInsert.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 100).Value = "Gutierrez";
                cmdInsert.Parameters.Add("@DireccionCifrada", SqlDbType.VarBinary, -1).Value = (object)direccionCifrada ?? DBNull.Value;
                cmdInsert.Parameters.Add("@TelefonoCifrado", SqlDbType.VarBinary, -1).Value = (object)telefonoCifrado ?? DBNull.Value;
                cmdInsert.Parameters.Add("@CorreoCifrado", SqlDbType.VarBinary, -1).Value = (object)correoCifrado ?? DBNull.Value;
                cmdInsert.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = new DateTime(2000, 1, 1);
                cmdInsert.Parameters.Add("@ClaveHash", SqlDbType.VarBinary, 32).Value = claveHash;
                cmdInsert.Parameters.Add("@ClaveSalt", SqlDbType.VarBinary, 16).Value = claveSalt;
                cmdInsert.Parameters.Add("@IdRol", SqlDbType.Int).Value = 1;
                cmdInsert.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = 1;
                cmdInsert.Parameters.Add("@IdSueldo", SqlDbType.Int).Value = 1;

                cmdInsert.ExecuteNonQuery();
            }
        }

        private static bool ComparacionTiempoConstante(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }

            return diff == 0;
        }
    }
}
