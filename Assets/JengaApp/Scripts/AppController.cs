using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace JengaApp
{
    public class AppController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private JengaStacksController stacksController;

        #endregion

        #region Unity Hooks

        private void Start()
        {
            // TODO: This is temporary and hard-coded. To implement a WebAPIManager.
            var json = Resources.Load<TextAsset>("json_data");
            var gradeData = JsonConvert.DeserializeObject<StandardizedGradeJengaBlock[]>(json.text);

            // Split and organise the data.
            var groupedData = gradeData.GroupBy(item => item.Grade);
            var configs = new List<JengaStackConfig>();
            foreach (var group in groupedData)
            {
                var sortedData = group
                                    .OrderBy(x => x.Domain)
                                    .ThenBy(x => x.Cluster)
                                    //.ThenBy(x => x.GetStandardIdSortKey()) // TODO: Organise by standard ID.
                                    .ToArray();

                // Create the configs.
                var config = new JengaStackConfig
                {
                    Blocks = sortedData
                };
                configs.Add(config);
            }

            // Initialise.
            stacksController.Initialise(configs.ToArray());
        }

        #endregion
    }
}
