using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Policlinico;
using System.Data.SqlClient;
using System.Data;

namespace DA.Policlinico
{
    public class EspecialidadDA
    {
        public List<EspecialidadBE> getEspecialidadList(EspecialidadBE Bespeciali)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("UPS_ESPECIALIDAD_MANT", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Opc", 1));
                cmd.Parameters.Add(new SqlParameter("@CodEsp", Bespeciali.CodEsp));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", Bespeciali.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@idEstado", Bespeciali.Estado));

                IDataReader reader = cmd.ExecuteReader();

                List<EspecialidadBE> especialidadList = new List<EspecialidadBE>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        EspecialidadBE especialidad = new EspecialidadBE();
                        especialidad.Id = reader.GetInt32(0);
                        especialidad.CodEsp = reader.GetString(1);
                        especialidad.Descripcion = reader.GetString(2);
                        especialidad.PrecioConsulta = decimal.ToDouble(reader.GetDecimal(3));
                        especialidad.MontoMedico = decimal.ToDouble(reader.GetDecimal(4));
                        especialidad.Estado = reader.GetInt32(5);
                        especialidad.EstadoDesc = reader.GetString(6);
                        especialidad.FechaRegistro = reader.GetDateTime(7);

                        especialidadList.Add(especialidad);
                    }
                }

                cnx.Close();
                return especialidadList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EspecialidadBE getEspecialidadbyID(EspecialidadBE Bespeciali)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("UPS_ESPECIALIDAD_MANT", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Opc", 2));
                cmd.Parameters.Add(new SqlParameter("@Id", Bespeciali.Id));

                IDataReader reader = cmd.ExecuteReader();

                EspecialidadBE especialidad = new EspecialidadBE();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        especialidad.Id = reader.GetInt32(0);
                        especialidad.CodEsp = reader.GetString(1);
                        especialidad.Descripcion = reader.GetString(2);
                        especialidad.PrecioConsulta = decimal.ToDouble(reader.GetDecimal(3));
                        especialidad.MontoMedico = decimal.ToDouble(reader.GetDecimal(4));
                        especialidad.Estado = reader.GetInt32(5);
                        especialidad.EstadoDesc = reader.GetString(6);
                        especialidad.FechaRegistro = reader.GetDateTime(7);
                    }
                }

                cnx.Close();
                return especialidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertEspecialidad(EspecialidadBE Bespeciali)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("UPS_ESPECIALIDAD_MANT", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Opc", 3));
                cmd.Parameters.Add(new SqlParameter("@CodEsp", Bespeciali.CodEsp));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", Bespeciali.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@PrecioConsulta", Bespeciali.PrecioConsulta));
                cmd.Parameters.Add(new SqlParameter("@MontoMedic", Bespeciali.MontoMedico));
                cmd.Parameters.Add(new SqlParameter("@idEstado", Bespeciali.Estado));

                int result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int editEspecialidad(EspecialidadBE Bespeciali)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("UPS_ESPECIALIDAD_MANT", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Opc", 4));
                cmd.Parameters.Add(new SqlParameter("@Id", Bespeciali.Id));
                cmd.Parameters.Add(new SqlParameter("@CodEsp", Bespeciali.CodEsp));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", Bespeciali.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@PrecioConsulta", Bespeciali.PrecioConsulta));
                cmd.Parameters.Add(new SqlParameter("@MontoMedic", Bespeciali.MontoMedico));
                cmd.Parameters.Add(new SqlParameter("@idEstado", Bespeciali.Estado));

                int result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteEspecialidad(EspecialidadBE Bespeciali)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("UPS_ESPECIALIDAD_MANT", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Opc", 5));
                cmd.Parameters.Add(new SqlParameter("@Id", Bespeciali.Id));

                int result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EspecialidadBE getEspecialidadCod()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("UPS_ESPECIALIDAD_MANT", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Opc", 6));

                IDataReader reader = cmd.ExecuteReader();

                EspecialidadBE especialidad = new EspecialidadBE();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        especialidad.CodEsp = reader.GetString(0);
                    }
                }

                cnx.Close();
                return especialidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
