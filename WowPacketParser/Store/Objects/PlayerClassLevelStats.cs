using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.SQL;

namespace WowPacketParser.Store.Objects
{
    [DBTableName("player_classlevelstats")]
    public sealed class PlayerClassLevelStats : IDataModel
    {
        [DBFieldName("class", true)]
        public Class? Class;

        [DBFieldName("level", true)]
        public byte? Level;

        [DBFieldName("str")]
        public int? Strength;

        [DBFieldName("agi")]
        public int? Agility;

        [DBFieldName("sta")]
        public int? Stamina;

        [DBFieldName("inte")]
        public int? Intellect;

        [DBFieldName("VerifiedBuild")]
        public int? VerifiedBuild = ClientVersion.BuildInt;

        public Race Race;

        public bool Recalculated = false;
    }
}