using Rituals.Contracts;
using Rituals.Runeforge;

namespace VaultAccess.Api;

public class Runeforge : DormantRuneforge
{
    protected override IEnumerable<IRune> Frostmourne()
    {
        // No need to invoke further runes—the Fallen Crusader suffices.
        return [];
    }
}