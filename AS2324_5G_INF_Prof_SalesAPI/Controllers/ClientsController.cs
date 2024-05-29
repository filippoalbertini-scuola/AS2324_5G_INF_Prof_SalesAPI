using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SQLite;

namespace AS2324_5G_INF_Prof_SalesAPI.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("GetClients")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataTable))]
        public JsonResult GetClients()
        {
            DataTable? dtbClients = null;

            string query = "";

            // connessione al DB in SQL Lite (vedi www.connectionstrings.com)

            string strConn = @"Data Source=" + "C:\\Appl\\Scuola\\AS_2023_2024\\5G\\AS2324_5G_INF_Prof_SalesAPI\\AS2324_5G_INF_Prof_SalesAPI\\Database\\northwindITA.db" + ";Pooling=false;Synchronous=Full;"; ;

            SQLiteConnection conn = new SQLiteConnection(strConn);
            conn.Open();


            // carico il data table clienti

            // prepara la QUERY
            query = "";
            query = query + "SELECT ";
            query = query + "   IdCliente, NomeSocieta, Indirizzo ";
            query = query + "FROM ";
            query = query + "   Clienti ";

            // crea DataAdapter
            SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);

            // popola il DataTable con DataAdapter 
            dtbClients = new DataTable();
            da.Fill(dtbClients);

            conn.Close();

            //return Json(new { output = dtbClients });
            return Json(dtbClients);
        }
    }
}
