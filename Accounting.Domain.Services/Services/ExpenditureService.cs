using Accounting.Domain.Services.Service.Interface;
using Accounting.Domain.Services.Utillies;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly UnitOfWork uow;

        public ExpenditureService()
        {
            uow = new UnitOfWork();
        }

        public IList<Expenditure> GetExpenditureByDateRequest(DateRequest dateRequest)
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenditureRepository.GetExpenditureByDateRequest(dateRequest);
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<ExpenditureType> GetExpenditureTypes()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenditureRepository.GetExpenditureTypes();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<ExpenditureRule> GetExpenditureRules()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenditureRepository.GetExpenditureRules();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<ExpenditureOverview> GetExpenditureOverview()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenditureRepository.GetExpenditureOverview(Extensions.GetCurrentMonth());
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<ExpenditureOverview> GetExpenditureRuleOverview()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenditureRepository.GetExpenditureRuleOverview(Extensions.GetCurrentMonth());
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<ExpenditureOverview> GetExpenditureRuleOverview(DateRequest dateRequest)
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenditureRepository.GetExpenditureRuleOverview(dateRequest);
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void ImportExpenditure(DateRequest dateRequest)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.ImportExpenditure(dateRequest);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveExpenditureRule(SaveExpenditureTypeRequest expenditureRequest)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.SaveExpenditureRule(expenditureRequest);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void UpdateExpenditure(UpdateExpenditureRequest expenditureRequest)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.UpdateExpenditure(expenditureRequest);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void UpdateExpenditureRule(UpdateExpenditureRuleRequest expenditureRequest)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.UpdateExpenditureRule(expenditureRequest);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteExpenditureRule(DeleteExpenditureRuleRequest expenditureRequest)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.DeleteExpenditureRule(expenditureRequest);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void AutoResolveMappings(DateRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.AutoResolveMappings(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
