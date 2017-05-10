using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectX.DTO
{
    class Folder
    {
        string name;
        string url;
        string time;
        string status;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Folder(string name, string url, string time, string status)
        {
            this.Name = name;
            this.Url = url;
            this.Time = time;
            this.Status = status;
        }

      }
}
