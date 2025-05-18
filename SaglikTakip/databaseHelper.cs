using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class databaseHelper
{
    // MSSQL bağlantı cümlesi
    private static string connectionString = "Server=MONSTER\\SQLEXPRESS;Database=SaglikTakip;Trusted_Connection=True;";

    /// <summary>
    /// INSERT, UPDATE, DELETE gibi sorguları çalıştırır ve etkilenen satır sayısını döner.
    /// </summary>
    public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteNonQuery(); // Değişiklik burada: int döner
            }
        }
    }

    /// <summary>
    /// SELECT sorgularını çalıştırır ve sonucu DataTable olarak döner.
    /// </summary>
    public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
