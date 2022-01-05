using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.SQL;

namespace WowPacketParser.Store.Objects
{
    [DBTableName("creature_template_resistance")]
    public sealed record CreatureTemplateResistance : IDataModel
    {
        [DBFieldName("CreatureID", true)]
        public uint? CreatureID;

        [DBFieldName("School", true)]
        public byte? School;

        [DBFieldName("Resistance")]
        public short? Resistance;

        [DBFieldName("VerifiedBuild")]
        public int? VerifiedBuild = ClientVersion.BuildInt;

        public string ModifyingAuras;
    }
}
