using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Store;
using WowPacketParser.Store.Objects;

namespace WowPacketParser.SQL.Builders
{
    [BuilderClass]
    public static class Spells
    {
        [BuilderMethod]
        public static string SpellTargetPosition()
        {
            if (Storage.SpellTargetPositions.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.spell_target_position))
                return string.Empty;

            return SQLUtil.Compare(Storage.SpellTargetPositions, SQLDatabase.Get(Storage.SpellTargetPositions), t => t.EffectHelper);
        }

        [BuilderMethod]
        public static string SpellTotemModel()
        {
            if (Storage.SpellTotemModels.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.spell_target_position))
                return string.Empty;

            foreach (var elem in Storage.SpellTotemModels)
            {
                if (!Storage.Objects.ContainsKey(elem.Item1.TotemGUID))
                    continue;
                Unit obj = Storage.Objects[elem.Item1.TotemGUID].Item1 as Unit;
                elem.Item1.DisplayID = obj.UnitData.DisplayID;
                if (obj.UnitData.CreatedBy.GetHighType() != HighGuidType.Player)
                    continue;

                if (Storage.Objects.ContainsKey(obj.UnitData.CreatedBy))
                {
                    Player creator = Storage.Objects[obj.UnitData.CreatedBy].Item1 as Player;
                    elem.Item1.RaceID = (byte)creator.Race;
                }
                elem.Item1.Comment = ((Race)elem.Item1.RaceID).ToString() + " - " + StoreGetters.GetName(StoreNameType.Spell, (int)elem.Item1.SpellID);
            }

            return SQLUtil.Compare(Storage.SpellTotemModels, SQLDatabase.Get(Storage.SpellTotemModels), t => t.Comment);
        }
    }
}
