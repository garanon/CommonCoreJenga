using System;
using System.Text.RegularExpressions;
using CommonCore;
using UnityEngine;

namespace JengaApp
{
    public class StandardizedGradeJengaBlock : IJengaBlockData, IStandardizedGradeData
    {
        #region Properties

        // IJengaBlockData properties
        public BlockType BlockType
        {
            get
            {
                if (!Enum.IsDefined(typeof(BlockType), Mastery))
                    return BlockType.Invalid;

                return (BlockType)Mastery;
            }
        }

        // IStandardizedGradeData properties
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public int Mastery { get; set; }
        public string DomainId { get; set; }
        public string Domain { get; set; }
        public string Cluster { get; set; }
        public string StandardId { get; set; }
        public string StandardDescription { get; set; }

        #endregion

        #region Public Methods

        public int GetStandardIdSortKey()
        {
            // Create a regex pattern to match all possible keys to the StandardId.
            var pattern = string.Join("|", Enum.GetNames(typeof(CommonCoreMathsStandardsKeys)));
            var match = Regex.Match(StandardId, pattern);

            // Convert the matched enum value into an integer.
            if (match.Success)
            {
                var enumValue = Enum.Parse(typeof(CommonCoreMathsStandardsKeys), match.Value);
                return Convert.ToInt32(enumValue);
            }
            else
            {
                Debug.LogError($"Standard ID [{StandardId}] does not contain any key that maps to enum [{nameof(CommonCoreMathsStandardsKeys)}]");
                return -1;
            }
        }

        #endregion
    }
}
