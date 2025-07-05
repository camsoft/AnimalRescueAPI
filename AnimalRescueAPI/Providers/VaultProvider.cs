using System.Text.Json;
using System.Threading.Tasks;

namespace AnimalRescueAPI.Providers
{
    public class VaultProvider : ConfigurationProvider
    {
        private readonly VaultClient _vaultClient;
        public VaultProvider(VaultClient vaultClient)
        {
            _vaultClient = vaultClient;
        }

        public override void Load()
        {
            LoadAsync().Wait();
        }

        public async Task LoadAsync()
        {
            await GetDatabaseCredentials();
        }
        public async Task GetDatabaseCredentials()
        {
            try
            {
                if (_vaultClient.SecretsType == "secrets")
                {
                    using (StreamReader reader = new StreamReader("/opt/epaas/vault/secrets/secrets"))
                    {
                        var json = reader.ReadToEnd();
                        var secrets = json.Replace("\\n", ",").Replace("\r\n", ",").Replace("\n", ",").Split(",", StringSplitOptions.RemoveEmptyEntries);

                        if (secrets != null)
                        {
                            Data.Add("database:userID", secrets.Where(x => x.Contains("userID")).FirstOrDefault()?.Split('=')[1]);
                            Data.Add("database:password", secrets.Where(x => x.Contains("password")).FirstOrDefault()?.Split('=')[1]);
                            Data.Add("database:server", secrets.Where(x => x.Contains("server")).FirstOrDefault()?.Split('=')[1]);
                        }
                    }
                }
                else
                {
                    using (StreamReader reader = new StreamReader("/AnimalRescueAPI/secrets"))
                    {
                        var json = reader.ReadToEnd();
                        var secrets = json.Replace("\\n", ",").Replace("\r\n", ",").Replace("\n", ",").Split(",", StringSplitOptions.RemoveEmptyEntries);

                        if (secrets != null)
                        {
                            Data.Add("database:userID", secrets.Where(x => x.Contains("userID")).FirstOrDefault()?.Split('=')[1]);
                            Data.Add("database:password", secrets.Where(x => x.Contains("password")).FirstOrDefault()?.Split('=')[1]);
                            Data.Add("database:server", secrets.Where(x => x.Contains("server")).FirstOrDefault()?.Split('=')[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load secrets from Vault", ex);
            }
        }
    }
}
