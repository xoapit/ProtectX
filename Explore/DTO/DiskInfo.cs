using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo
{
    class DiskInfo
    {
        String drive = "", capacity = "", mediaType = "", freeSpace = "", status = "", used = "";

        public string Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }

        public string Used
        {
            get
            {
                return used;
            }

            set
            {
                used = value;
            }
        }

        public string Drive
        {
            get
            {
                return drive;
            }

            set
            {
                drive = value;
            }
        }

        public string FreeSpace
        {
            get
            {
                return freeSpace;
            }

            set
            {
                freeSpace = value;
            }
        }

        public string MediaType
        {
            get
            {
                return mediaType;
            }

            set
            {
                mediaType = value;
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
    }
}
