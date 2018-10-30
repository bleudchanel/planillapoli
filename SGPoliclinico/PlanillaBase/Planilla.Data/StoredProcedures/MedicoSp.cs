using Planilla.Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data
{
    public class MedicoSp
    {
        public void InsertMedicoExtra(int IdMedico) {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                try
                {
                    var IdMedicoParam = new SqlParameter("@IdMedico", IdMedico);
                    var result = entityContext.Database.SqlQuery<int>("dbo.InsertExtraMedico @IdMedico", IdMedicoParam).SingleOrDefault();
                    //return result.IdMedico;
                }
                catch(Exception ex)
                {
                    throw ex;
                }                
                //return result;
            }
            
            
        }

    }
}
