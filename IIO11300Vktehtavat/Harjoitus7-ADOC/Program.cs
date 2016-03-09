using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitus7_ADOC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Basic steps
                // 1) Luodaan yhteys
                string connStr = GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Avataan yhteys
                    conn.Open();

                    // 2) Tehdään SQL kysely, siitä luodaan Command-tyyppinen olio
                    string sql = "SELECT asioid, lastname, firstname FROM Presences WHERE asioid ='H8306'";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // 3) Käsitellään "tulos" tässä dataReader-olio
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // Käydään reader-olio läpi, forward-only
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Läsnäolosi {0} {1} {2}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2));
                        }
                        Console.WriteLine("Tiedot haettu onnistuneesti");
                    }

                    rdr.Close();
                    conn.Close();
                    Console.WriteLine("Tietokanta yhteys suljettu onnistuneesti");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.ReadKey();
            }
        }

        private static string GetConnectionString() {
            // Luetaan connection string App.configista
            return Harjoitus7_ADOC.Properties.Settings.Default.Tietokanta;
        }
    }
}
