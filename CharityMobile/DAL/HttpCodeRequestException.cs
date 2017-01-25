using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CharityMobile.DAL
{
    public class HttpCodeRequestException : Exception
    {
        public string InnerMessage { get; set; }
        public HttpStatusCode Code { get; set; }
        public Dictionary<int, string> CodeMessages = new Dictionary<int, string>
        {
            { 408, "Час запиту закінчився" },
            { 413, "Тіло запиту перевищує допустимий розмір" },
            { 500, "Внутрішня помилка серверу" },
            { 200, "Dc" },
            { 401, "Заборонено не авторизованим користувачам" },
            { 404, "Ресурс не знайдено" },
        };
        public HttpCodeRequestException(HttpStatusCode code)
        {
            Code = code;
            InnerMessage = CodeMessages[(int) code];
        }
    }
}
