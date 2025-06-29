namespace AnimalRescueAPI.Providers
{
    public class VaultConfigurationSource : IConfigurationSource
    {
        public VaultClient VaultClient { get; set; }

        public VaultConfigurationSource(VaultClient vaultClient)
        {
            VaultClient = vaultClient ?? throw new ArgumentNullException(nameof(vaultClient), "VaultClient cannot be null");
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new VaultProvider(VaultClient);
        }
    }

    public static class VaultConfigurationExtensions
    {
        public static IConfigurationBuilder AddVault(this IConfigurationBuilder builder, VaultClient vaultClient)
        {
            if (vaultClient == null)
            {
                throw new ArgumentNullException(nameof(vaultClient), "VaultClient cannot be null");
            }

            return builder.Add(new VaultConfigurationSource(vaultClient));
        }
    }
}
