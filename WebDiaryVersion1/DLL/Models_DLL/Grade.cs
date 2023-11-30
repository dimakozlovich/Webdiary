using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDiaryVersion1.DLL.Models_DLL
{
    public class Grade
    {
        public int Grade_id { get; set; }

        private string? Last_week;

        private string? This_week;

        private string? Next_week;

        public string[,,]? GetThisWeek()
        {
            if (this.This_week != null)
                return JsonConvert.DeserializeObject<string[,,]>(This_week);

            else
                return new string[0, 0, 0];
        }
        public string[,,]? GetNextWeek()
        {
            if (Next_week != null)
                return JsonConvert.DeserializeObject<string[,,]>(Next_week);

            else
                return new string[0, 0, 0];
        }
        public string[,,]? GetLastWeek()
        {
            if (Last_week != null)
                return JsonConvert.DeserializeObject<string[,,]>(Last_week);
            else
                return new string[0, 0, 0];
        }
    }
}
