using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace GeradorTicket_Jira
{
    class PgCon
    {
        private static string Host = "192.168.232.252";
        private static string User = "hd_suporte";
        private static string DBname = "bd0122";
        private static string Password = "s@tt30hd2013";
        private static string Port = "6000";

        static void Main(string[] args)
        {
            // Cria a conexão utilizando os parâmetros anteriores

            string connString =
                String.Format(
                        "Server={0};Username={1};Database={3};Port={4};SSLMode=Prefer",
                        Host,
                        User,
                        DBname,
                        Port,
                        Password);

            using (var conn = new NpgsqlConnection(connString))
            {
                MessageBox.Show("Conectando com o banco ...", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT DISTINCT nm_paciente FROM sigh.pacientes limit 10", conn))
                {
                    var reader = command.ExecuteReader();
                    string retorno;
                    while (reader.Read())
                    {
                        
                    }
                    MessageBox.Show("Conectando com o banco ...", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            
            }


        }

    }
}
