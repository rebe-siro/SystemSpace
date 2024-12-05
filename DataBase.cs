using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Npgsql;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSpace
{
    internal class DataBase
    {
        public MySqlDataReader reader;
        public MySqlConnection connection;
        public MySqlCommand command;

        string server, database, port, username, password, connectionString, sqlStatement;
        public DataBase()
        {
            server = "localhost";
            database = "System";
            port = "3306";
            username = "admin";
            password = "sistema";
            connectionString = "database = " + database + ";data source = " + server + ";port = " + port + ";user id = " + username + ";password = " + password;
            connection = new MySqlConnection(connectionString);

        }





        /////////////////////////ESPACIOS FISICOS////////////////////////////

        public void agregarEspacioFisico(string code, string description, string measures, int typespace, string status)
        {
            connection.Open();

            string sqlStatement = "INSERT INTO fisic_space values ('" + code + "', '" + description + "', '" + measures + "', '" + typespace + "','" + status + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public DataTable traerEspciofisicos()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción', typespace as 'Tipo de espacio', measures as 'Medidas' FROM fisic_space WHERE status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datos = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            datos.Fill(table);
            connection.Close();

            return table;
        }

        public DataTable traerEspciosfisicosPorDescription(String description)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',measures as 'Medidas',typespace as 'Tipo de espacio' FROM fisic_space  WHERE description LIKE '%" + description + "%' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datos = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            datos.Fill(table);
            connection.Close();

            return table;
        }

        public DataTable traerEspciosfisicosPorCodigo(String code)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',measures as 'Medidas',typespace as 'Tipo de espacio' FROM fisic_space where code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datos = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            datos.Fill(table);
            connection.Close();

            return table;
        }

        public DataTable eliminarLogicaEspacioFisico(String code)
        {
            connection.Open();
            sqlStatement = "UPDATE fisic_space SET status = 'O' WHERE code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datos = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            datos.Fill(table);
            connection.Close();

            return table;
        }

        public void modificarEspacioFisico(string description, string measures, int typespace, string status)
        {
            connection.Open();
            sqlStatement = "UPDATE fisic_space SET description = '" + description + "',measures = " + measures + ",typespace = " + typespace + " ,status = " + status + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerTypeEspacioFisicos()
        {
            connection.Open();
            sqlStatement = "SELECT description FROM type_fisicspace";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datos = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            datos.Fill(table);
            connection.Close();

            return table;
        }

        public int ultimoCode()
        {
            try
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT MAX(code) AS codigo_maximo FROM fisic_space", connection))
                {
                    object result = command.ExecuteScalar();
                    int maxCodigo = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    return maxCodigo + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último código: " + ex.Message);
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }





        /////////////////////////EMPLEADOS////////////////////////////

        public void modificarEmpleado(int codeSpeciality, int codeCharge, string names, string lastNames, string address, string telephone, string mail)
        {
            connection.Open();
            sqlStatement = "UPDATE employee SET codeSpeciality = '" + codeSpeciality + "',codeCharge = " + codeCharge + ",names = " + names + ",lastNames = " + lastNames + ",address = " + address + ",telephone = " + telephone + ",mail = " + mail + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerEmpleadoPorCode(String code)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',codeSpeciality as 'Especialidad',codeCharge as 'Cargo',names as 'Nombres',lastNames as 'Apellidos',address as 'Dirección',telephone as 'Teléfono',mail as 'Correo' FROM employee where code = '" + code + "' AND status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosE = new MySqlDataAdapter(command);
            DataTable tableE = new DataTable();
            datosE.Fill(tableE);
            connection.Close();

            return tableE;
        }

        public DataTable traerEmpleado()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',names as 'Nombres',lastNames as 'Apellidos',codeSpeciality as 'Especialidad',codeCharge as 'Cargo',address as 'Dirección',telephone as 'Teléfono',mail as 'Correo' FROM employee WHERE status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosE = new MySqlDataAdapter(command);
            DataTable tableE = new DataTable();
            datosE.Fill(tableE);
            connection.Close();

            return tableE;
        }

        public DataTable traerEmpleado2()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',names as 'Nombres',lastNames as 'Apellidos',codeSpeciality as 'Especialidad',codeCharge as 'Cargo' FROM employee WHERE status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosE = new MySqlDataAdapter(command);
            DataTable tableE = new DataTable();
            datosE.Fill(tableE);
            connection.Close();

            return tableE;
        }

        public void agregarEmpleado(string code, int codeSpeciality, int codeCharge, string names, string lastNames, string address, string telephone, string mail, string status)
        {
            connection.Open();
            string sqlStatement = "INSERT INTO employee values ('" + code + "', '" + codeSpeciality + "', '" + codeCharge + "', '" + names + "','" + lastNames + "','" + address + "','" + telephone + "','" + mail + "','" + status + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerSpeciality()
        {
            connection.Open();
            sqlStatement = "SELECT name FROM speciality";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosE = new MySqlDataAdapter(command);
            DataTable tableE = new DataTable();
            datosE.Fill(tableE);
            connection.Close();

            return tableE;
        }

        public DataTable traerCharge()
        {
            connection.Open();
            sqlStatement = "SELECT name FROM charge";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosE = new MySqlDataAdapter(command);
            DataTable tableE = new DataTable();
            datosE.Fill(tableE);
            connection.Close();

            return tableE;
        }

        public int ultimoCodeEmployee()
        {
            try
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT MAX(code) AS codigo_maximo FROM employee", connection))
                {
                    object result = command.ExecuteScalar();
                    int maxCodigoE = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    return maxCodigoE + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último código: " + ex.Message);
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataTable traerEmpleadoPS()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',codeSpeciality as 'Especialidad',codeCharge as 'Cargo',names as 'Nombres',lastNames as 'Apellidos',address as 'Dirección',telephone as 'Teléfono',mail as 'Correo' FROM employee WHERE status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosEPS = new MySqlDataAdapter(command);
            DataTable tableEPS = new DataTable();
            datosEPS.Fill(tableEPS);
            connection.Close();

            return tableEPS;
        }

        public DataTable traerPlanServicePorCode(String code)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',codeService as 'Servicio',codeEmployee as 'Empleado',codeSupl as 'suplente',codeFisicS as 'Espacio Fisico',daysSelec as 'días' FROM planservice where code = '" + code + "' AND status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosESP = new MySqlDataAdapter(command);
            DataTable tableESP = new DataTable();
            datosESP.Fill(tableESP);
            connection.Close();

            return tableESP;
        }
        public int ultimoCodePlanService()
        {
            try
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT MAX(code) AS codigo_maximo FROM planservice", connection))
                {
                    object result = command.ExecuteScalar();
                    int maxCodigoPS = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    return maxCodigoPS + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último código: " + ex.Message);
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataTable eliminarLogicaEmpleado(String code)
        {
            connection.Open();
            sqlStatement = "UPDATE employee SET status = 'O' WHERE code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosE = new MySqlDataAdapter(command);
            DataTable tableE = new DataTable();
            datosE.Fill(tableE);
            connection.Close();

            return tableE;
        }

        public DataTable traerEmpleadoPorName(String names)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',codeSpeciality as 'Especialidad',codeCharge as 'Cargo',names as 'Nombres',lastNames as 'Apellidos',address as 'Dirección',telephone as 'Teléfono',mail as 'Correo' FROM employee  WHERE names LIKE '%" + names + "%' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosE = new MySqlDataAdapter(command);
            DataTable tableE = new DataTable();
            datosE.Fill(tableE);
            connection.Close();

            return tableE;
        }

        /////////////////////////INVENTARIO////////////////////////////

        public void traerCodigoPlanServicio(String codigoPlanServicio)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código' from planservice where code = '" + codigoPlanServicio + "'";
            command = new MySqlCommand(sqlStatement, connection);
            connection.Close();
        }

        public void modificarInventario(string code, string description, int unit, string cost, string stock, string sMin)
        {
            connection.Open();
            sqlStatement = "UPDATE inventory SET code = '" + code + "',description = " + description + ",unit = " + unit + ",cost = " + cost + ",stock = " + stock + ",sMin = " + sMin + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerInventarioPorCode(String code)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',unit as 'Unidad',cost as 'Costo',stock as 'Cantidad',sMin as 'Stock Mínimo' FROM inventory where code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosI = new MySqlDataAdapter(command);
            DataTable tableI = new DataTable();
            datosI.Fill(tableI);
            connection.Close();

            return tableI;
        }

        public DataTable traerInventario()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',unit as 'Unidad',cost as 'Costo',stock as 'Cantidad',sMin as 'Stock Mínimo' FROM inventory where status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosI = new MySqlDataAdapter(command);
            DataTable tableI = new DataTable();
            datosI.Fill(tableI);
            connection.Close();

            return tableI;
        }

        public void agregarInventario(string code, string description, int unit, string cost, string stock, string sMin, string status)
        {
            connection.Open();
            string sqlStatement = "INSERT INTO inventory values ('" + code + "', '" + description + "', '" + unit + "', '" + cost + "','" + stock + "','" + sMin + "','" + status + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerUnit()
        {
            connection.Open();
            sqlStatement = "SELECT description FROM unit";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosI = new MySqlDataAdapter(command);
            DataTable tableI = new DataTable();
            datosI.Fill(tableI);
            connection.Close();

            return tableI;
        }

        public DataTable eliminarLogicaInventario(String code)
        {
            connection.Open();
            sqlStatement = "UPDATE inventory SET status = 'O' WHERE code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosI = new MySqlDataAdapter(command);
            DataTable tableI = new DataTable();
            datosI.Fill(tableI);
            connection.Close();

            return tableI;
        }

        public DataTable traerInventarioPorDescription(String description)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'code',description as 'description',unit as 'unit',cost as 'cost',stock as 'stock',sMin as 'sMin' FROM inventory  WHERE description LIKE '%" + description + "%' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosI = new MySqlDataAdapter(command);
            DataTable tableI = new DataTable();
            datosI.Fill(tableI);
            connection.Close();

            return tableI;
        }

        public void agregarMateriales(string codeS, string codeInventory)
        {
            connection.Open();

            string sqlStatement = "INSERT INTO materials values ('" + codeS + "', '" + codeInventory + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        /////////////////////////SERVICIOS////////////////////////////

        public void agregarPlanServicio(string code, string codeService, string codeEmployee, string codeSupl, string codeFisicS, string daysSelec, string status)
        {
            connection.Open(); 

            string sqlStatement = "INSERT INTO planservice values ('" + code + "', '" + codeService + "','" + codeEmployee + "','" + codeSupl + "','" + codeFisicS + "','" + daysSelec + "','" + status + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void agregarServicios(string code, string description, int sType, string status)
        {
            connection.Open();

            string sqlStatement = "INSERT INTO services values ('" + code + "', '" + description + "', '" + sType + "','" + status + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public DataTable TraerServicios()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción', sType as 'Tipo de Servicio' FROM services WHERE status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosV = new MySqlDataAdapter(command);
            DataTable tableV = new DataTable();
            datosV.Fill(tableV);
            connection.Close();

            return tableV;
        }

        public DataTable TraerPlanServicePorEmpleado(int codeEmployee)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',codeService as 'Servicio',codeSupl as 'suplente',codeFisicS as 'Espacio Fisico',daysSelec as 'días' FROM planservice where codeEmployee = '" + codeEmployee + "' AND status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosT = new MySqlDataAdapter(command);
            DataTable tableT = new DataTable();
            datosT.Fill(tableT);
            connection.Close();

            return tableT;
        }

        public DataTable traerServiciosPorDescription(String description)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',sType as 'Tipo de servicio' FROM services  WHERE description LIKE '%" + description + "%' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosS = new MySqlDataAdapter(command);
            DataTable tableS = new DataTable();
            datosS.Fill(tableS);
            connection.Close();

            return tableS;
        }

        public DataTable traerServiciosPorCodigo(String code)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',sType as 'Tipo de servicio' FROM services where code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosS = new MySqlDataAdapter(command);
            DataTable tableS = new DataTable();
            datosS.Fill(tableS);
            connection.Close();

            return tableS;
        }

        public DataTable eliminarLogicaServicios(String code)
        {
            connection.Open();
            sqlStatement = "UPDATE services SET status = 'O' WHERE code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosS = new MySqlDataAdapter(command);
            DataTable tableS = new DataTable();
            datosS.Fill(tableS);
            connection.Close();

            return tableS;
        }

        public void modificarServicios(string description, int sType, string status)
        {
            connection.Open();
            sqlStatement = "UPDATE fisic_space SET description = '" + description + "',sType = " + sType + " ,status = " + status + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerTypeServicio()
        {
            connection.Open();
            sqlStatement = "SELECT description FROM type_services";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosS = new MySqlDataAdapter(command);
            DataTable tableS = new DataTable();
            datosS.Fill(tableS);
            connection.Close();

            return tableS;
        }

        public int ultimoCodeServices()
        {
            try
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT MAX(code) AS codigo_maximo FROM services", connection))
                {
                    object resultS = command.ExecuteScalar();
                    int maxCodigoS = resultS == DBNull.Value ? 0 : Convert.ToInt32(resultS);
                    return maxCodigoS + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último código: " + ex.Message);
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        /////////////////////////USUARIOS////////////////////////////

        public void modificarUser(string code, string userName, string name, string password, int type, string mail)
        {
            connection.Open();
            sqlStatement = "UPDATE user SET userName = '" + userName + "',name = " + name + ",password = " + password + ",type = " + type + ",mail = " + mail + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerUserPorCode(String code)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',userName as 'User',name as 'Nombre',password as 'Contraseña',type as 'Rol',mail as 'Correo' FROM user where code = '" + code + "' AND status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }

        public DataTable traeruser()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',userName as 'User',name as 'Nombre',password as 'Contraseña',type as 'Rol',mail as 'Correo' FROM user WHERE status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }

        public void agregarUser(string code, string userName, string name, string password, int type, string mail, string status)
        {
            connection.Open();
            string sqlStatement = "INSERT INTO user values ('" + code + "', '" + userName + "', '" + name + "','" + password + "','" + type + "','" + mail + "','" + status + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable traerTypeUser()
        {
            connection.Open();
            sqlStatement = "SELECT description FROM userType";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }

        public int ultimoCodeUser()
        {
            try
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT MAX(code) AS codigo_maximo FROM user", connection))
                {
                    object resultU = command.ExecuteScalar();
                    int maxCodigoU = resultU == DBNull.Value ? 0 : Convert.ToInt32(resultU);
                    return maxCodigoU + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último código: " + ex.Message);
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataTable eliminarLogicaUsuario(String code)
        {
            connection.Open();
            sqlStatement = "UPDATE user SET status = 'O' WHERE code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }

        public DataTable traerUserPorName(String name)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',userName as 'User',name as 'Nombre',password as 'Contraseña',type as 'Rol',mail as 'Correo' FROM user  WHERE names LIKE '%" + name + "%' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }

        public DataTable traerUserPorUser(String userName)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',userName as 'User',name as 'Nombre',password as 'Contraseña',type as 'Rol',mail as 'Correo' FROM user  WHERE userName LIKE '%" + userName + "%' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }

        public DataTable traerUserPassword(String code)
        {
            connection.Open();
            sqlStatement = "SELECT password FROM user WHERE code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }
        public DataTable traerUserName(String code)
        {
            connection.Open();
            sqlStatement = "SELECT userName FROM user WHERE status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosU = new MySqlDataAdapter(command);
            DataTable tableU = new DataTable();
            datosU.Fill(tableU);
            connection.Close();

            return tableU;
        }

        /////////////////////////ORGANIZACION////////////////////////////

        public void traerOrganization(String rif)
        {
            connection.Open();
            sqlStatement = "SELECT * FROM organization where rif = '" + rif + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public void modificarOrganization(String rif, String name, String address, String boss)
        {
            connection.Open();
            sqlStatement = "UPDATE organization SET rif = '" + rif + "',name = " + name + ",address = " + address + ",boss = " + boss + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void agregarOrganization(String rif, String name, String address, String boss)
        {
            connection.Open();
            string sqlStatement = "INSERT INTO user values ('" + rif + "', '" + name + "','" + address + "','" + boss + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        /////////////////////////RECHAZOS////////////////////////////
        public void agregarRechazo(string code, string description, string details, string status)
        {
            connection.Open();

            string sqlStatement = "INSERT INTO rejection values ('" + code + "', '" + description + "', '" + details + "','" + status + "')";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public DataTable traerRechazo()
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción', details as 'Detalles' FROM rejection WHERE status = 'A' order by code";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosR = new MySqlDataAdapter(command);
            DataTable tableR = new DataTable();
            datosR.Fill(tableR);
            connection.Close();

            return tableR;
        }

        public DataTable traerRechazoPorDescription(String description)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',details as 'Detalles' FROM rejection WHERE description LIKE '%" + description + "%' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosR = new MySqlDataAdapter(command);
            DataTable tableR = new DataTable();
            datosR.Fill(tableR);
            connection.Close();

            return tableR;
        }

        public DataTable traerRechazoPorCodigo(String code)
        {
            connection.Open();
            sqlStatement = "SELECT code as 'Código',description as 'Descripción',details as 'Detalles' FROM rejection where code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosR = new MySqlDataAdapter(command);
            DataTable tableR = new DataTable();
            datosR.Fill(tableR);
            connection.Close();

            return tableR;
        }

        public DataTable eliminarLogicaRechazo(String code)
        {
            connection.Open();
            sqlStatement = "UPDATE rejection SET status = 'O' WHERE code = '" + code + "' AND status = 'A'";
            command = new MySqlCommand(sqlStatement, connection);
            MySqlDataAdapter datosR = new MySqlDataAdapter(command);
            DataTable tableR = new DataTable();
            datosR.Fill(tableR);
            connection.Close();

            return tableR;
        }

        public void modificarRechazo(string description, string details, string status)
        {
            connection.Open();
            sqlStatement = "UPDATE rejection SET description = '" + description + "',details = " + details + ",status = " + status + "'";
            command = new MySqlCommand(sqlStatement, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int ultimoCodeR()
        {
            try
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT MAX(code) AS codigo_maximo FROM rejection", connection))
                {
                    object result = command.ExecuteScalar();
                    int maxCodigo = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    return maxCodigo + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último código: " + ex.Message);
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


    }


}
