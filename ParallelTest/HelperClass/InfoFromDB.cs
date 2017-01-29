using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Collections.Generic;
using System.Data;

namespace DBCompareWithUIParallelOptions.HelperClass
{
    public class InfoFromDB : TestBaseClass
    {
        private string externalId;

        public string checkIfExternalIdCorrespondsInternalId(string externalId)
        {
            string internalId = null;
            try
            {
                //connect to DB
                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User ID=user;Password=password;";

                //create connection
                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                //create query
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select tm.internalid from TRANSIT_MASTERLINKS tm 
                    where tm.externalid = {0} 
                    and tm.masterlinktypeid = 2
                    and tm.mastersystemid = 18",
                    externalId);

                //read answer
                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    internalId = reader.GetInt32(0).ToString();
                }
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
                //close connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return internalId;
        }

        public List<string> getDataFromStaging_Transit_Agreems(string externalId)
        {
            List<string> valuesStaging_Transit_Agreems = new List<string>();
            try
            {
                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User Id = user; Password = password;";

                //create connection
                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                //create query
                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select * from TRANSIT_AGREEMS t 
                    where t.agreemid = {0}", externalId);

                //read answer
                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(0).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(1).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(2).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(3).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(4).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(5).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(6).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(7).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(8).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(9).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(10).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(11).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(12).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(13).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(14).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(15).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(16).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(17).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(18).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(19).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(20).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(21).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(22).ToString());
                    valuesStaging_Transit_Agreems.Add(reader.GetValue(23).ToString());
                }
                //close reader
                if (reader != null)
                {
                    reader.Close();
                }
                //close connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return valuesStaging_Transit_Agreems;
        }

        public List<string> getDataFromStaging_Transit_Persons(string externalId)
        {
            List<string> valuesStaging_Transit_Persons = new List<string>();
            try
            {
                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User Id = user; Password = password;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select * from TRANSIT_PERSONS tp 
                    join TRANSIT_AGREEMS ta
                    on tp.personid = ta.personid
                    where ta.agreemid = {0}",
                    externalId);

                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    valuesStaging_Transit_Persons.Add(reader.GetValue(0).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(1).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(2).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(3).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(4).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(5).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(6).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(7).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(8).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(9).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(10).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(11).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(12).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(13).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(14).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(15).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(16).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(17).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(18).ToString());
                    valuesStaging_Transit_Persons.Add(reader.GetValue(19).ToString());
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return valuesStaging_Transit_Persons;
        }

        public List<string> getDataFromStaging_Transit_Deliquency(string externalId)
        {
            List<string> valuesStaging_Transit_Deliquency = new List<string>();
            try
            {
                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User Id = user; Password = password;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select * from TRANSIT_DELINQUENCY t 
                    where t.agreemid = {0}",
                    externalId);

                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(0).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(1).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(2).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(3).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(4).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(5).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(6).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(7).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(8).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(9).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(10).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(11).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(12).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(13).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(14).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(15).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(16).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(17).ToString());
                    valuesStaging_Transit_Deliquency.Add(reader.GetValue(18).ToString());
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return valuesStaging_Transit_Deliquency;
        }

        public int checkIfClientIdHasAnotherAgreemsInCollectSM(string externalId)
        {
            int count = 0;
            try
            {
                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User ID=user;Password=password;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select count(*) from TRANSIT_MASTERLINKS tm 
                    where tm.internalid IN
                    (select ta.clientid from TRANSIT_AGREEMS ta 
                  where ta.agreemid IN 
                    (select t.internalid from TRANSIT_MASTERLINKS t 
                  where t.externalid = {0})) 
                    and tm.masterlinktypeid = 1
                    and tm.mastersystemid = 18", externalId);

                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return count;
        }

        public string getSubproductName(string externalId)
        {
            string subproduct = null;
            try
            {

                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User ID=user;Password=password;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select cds.nickname from CollectSM.DICTIONARY_SUBPRODUCT cds
                    join staging.TRANSIT_AGREEMS sta
                    on cds.subproductid = sta.subproduct
                    where sta.agreemid = {0}", externalId);

                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    subproduct = reader.GetString(0);
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return subproduct;
        }

        public List<string> getDataFromStaging_Transit_Contacts_Phones(string externalId)
        {
            List<string> valuesStaging_Transit_Contacts_Phones = new List<string>();
            try
            {
                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User Id = user; Password = password;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select tcp.phone from staging.TRANSIT_CONTACTS_PHONES tcp
                    join staging.TRANSIT_AGREEMS ta
                    on tcp.personid = ta.personid
                    where ta.agreemid = {0}",
                    externalId);

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    valuesStaging_Transit_Contacts_Phones.Add(reader.GetString(0));
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return valuesStaging_Transit_Contacts_Phones;
        }

        public List<PhoneMasks> getInfoFromT_PHONECODESUA()
        {
            List<PhoneMasks> query = new List<PhoneMasks>();
            try
            {
                string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User ID=user;Password=password;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = @"select REGEX_MASK as PhoneMask, MOBILE from T_PHONECODESUA";

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    query.Add(new PhoneMasks() { Mobile = reader.GetInt32(1), PhoneMask = reader.GetString(0) });
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Data);
            }
            return query;
        }

        public static List<string> getAllExternalIdFromStaging()
        {
            string connectionString = @"Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = myhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = myservice)));User Id = user; Password = password;";
            List<string> externalIds = new List<string>();

            using (OracleConnection connection = new OracleConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = String.Format(@"select t.agreemid from TRANSIT_AGREEMS t");

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    externalIds.Add(reader[0].ToString());
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
                return externalIds;
            }
        }
    }
}
