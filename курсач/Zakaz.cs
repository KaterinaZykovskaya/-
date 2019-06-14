using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач
{
    class Zakaz
    {
        private string famk;
        private string famv;
        private string data;
        private string time;
        private string service;
        private string namber;

        public Zakaz(string famk, string famv, string data,string time, string service, string namber)
        {
            this.famk = famk;
            this.famv = famv;
            this.data = data;
            this.time= time;
            this.service = service;
            this.namber = namber;

        }
    }
}
