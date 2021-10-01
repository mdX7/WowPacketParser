using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.SQL;

namespace WowPacketParser.Store.Objects
{
    [DBTableName("spell_totem_model")]
    public sealed class SpellTotemModel : IDataModel
    {
        [DBFieldName("SpellID", true)]
        public uint? SpellID;

        [DBFieldName("RaceID", true)]
        public byte? RaceID;

        [DBFieldName("DisplayID")]
        public int? DisplayID;

        public WowGuid TotemGUID;
        public string Comment;
    }
}