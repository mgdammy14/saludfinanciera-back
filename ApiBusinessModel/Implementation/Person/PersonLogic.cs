using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using ApiBusinessModel.Interfaces.General;
using ApiBusinessModel.Interfaces.Person;
using ApiModel.General;
using ApiModel.Person;
using ApiModel.RequestDTO.Client;
using ApiModel.RequestDTO.Person;
using ApiModel.ResponseDTO.Person;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Person
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadFileLogic _uploadFileLogic;

        public PersonLogic(IUnitOfWork unitOfWork, IUploadFileLogic uploadFileLogic)
        {
            _unitOfWork = unitOfWork;
            _uploadFileLogic = uploadFileLogic;
        }

        public int InsertPerson(PersonFullRequestDTO dto)
        {
            try
            {
                int resultado = 0;
                using (var transaction = new TransactionScope())
                {
                    ApiModel.Person.Person objPerson = new ApiModel.Person.Person();
                    objPerson.idPersonType = 1;
                    objPerson.idPersonState = 1;

                    int idPersonCreated = _unitOfWork.IPerson.Insert(objPerson.Mapper(objPerson, dto.client));
                    resultado = idPersonCreated;

                    PersonExtraData objPersonExtraData = new PersonExtraData();
                    objPersonExtraData.idPerson = idPersonCreated;
                    int idPersonExtraDataCreated = 0;
                    if(dto.extraClientData == null)
                    {
                        idPersonExtraDataCreated = _unitOfWork.IPersonExtraData.Insert(objPersonExtraData);
                    }
                    else
                    {
                        idPersonExtraDataCreated = _unitOfWork.IPersonExtraData.Insert(objPersonExtraData.Mapper(objPersonExtraData, dto.extraClientData));
                    }

                    LaborData objLaborData = new LaborData();
                    objLaborData.idPerson = idPersonCreated;
                    int idLaborDataCreated = 0;
                    if(dto.laborData == null)
                    {
                        idLaborDataCreated = _unitOfWork.ILaborData.Insert(objLaborData);
                    }
                    else
                    {
                        idLaborDataCreated = _unitOfWork.ILaborData.Insert(objLaborData.Mapper(objLaborData, dto.laborData));
                    }

                    int idSpouseCreated = 0;
                    if (dto.spouse == null)
                    {
                        ApiModel.Person.Person objSpouse = new ApiModel.Person.Person();
                        objSpouse.idPersonType = 2;
                        objSpouse.idPersonState = 1;
                        idSpouseCreated = _unitOfWork.IPerson.Insert(objSpouse);

                        LaborData objSpouseLaborData = new LaborData();
                        objSpouseLaborData.idPerson = idSpouseCreated;
                        int idSpouseLaborDataCreated = 0;
                        idSpouseLaborDataCreated = _unitOfWork.ILaborData.Insert(objSpouseLaborData);
                    }
                    else
                    {

                        ApiModel.Person.Person objSpouse = new ApiModel.Person.Person();
                        objSpouse.idPersonType = 2;
                        objSpouse.idPersonState = 1;
                        if (dto.spouse.spouseData == null)
                        {
                            idSpouseCreated = _unitOfWork.IPerson.Insert(objSpouse);
                        }
                        else
                        {
                            idSpouseCreated = _unitOfWork.IPerson.Insert(objSpouse.Mapper(objSpouse, dto.spouse.spouseData));
                        }

                        LaborData objSpouseLaborData = new LaborData();
                        objSpouseLaborData.idPerson = idSpouseCreated;
                        int idSpouseLaborDataCreated = 0;
                        if (dto.laborData == null)
                        {
                            idSpouseLaborDataCreated = _unitOfWork.ILaborData.Insert(objSpouseLaborData);
                        }
                        else
                        {
                            idSpouseLaborDataCreated = _unitOfWork.ILaborData.Insert(objLaborData.Mapper(objSpouseLaborData, dto.spouse.spouseLaborData));
                        }
                    }

                    SpousePerson spousePersonCreated = new SpousePerson();
                    spousePersonCreated.idClient = idPersonCreated;
                    spousePersonCreated.idSpouse = idSpouseCreated;
                    var idSpousePersonCreated = _unitOfWork.ISpousePerson.Insert(spousePersonCreated);


                    List<SpouseRequestDTO> referenceListCreated = new List<SpouseRequestDTO>();
                    SpouseRequestDTO referenceToAddList = new SpouseRequestDTO();



                    if (dto.referenceList == null)
                    {
                        referenceListCreated.Add(referenceToAddList);
                        referenceListCreated.Add(referenceToAddList);

                        foreach (var item in referenceListCreated)
                        {
                            ApiModel.Person.Person referenceToAdd = new ApiModel.Person.Person();
                            referenceToAdd.idPersonType = 3;
                            referenceToAdd.idPersonState = 1;
                            var idReferenceCreated = _unitOfWork.IPerson.Insert(referenceToAdd);

                            PersonReference personReferenceCreated = new PersonReference();
                            personReferenceCreated.idClient = idPersonCreated;
                            personReferenceCreated.idReference = idReferenceCreated;
                            var idPersonReferenceCreated = _unitOfWork.IPersonReference.Insert(personReferenceCreated);
                        }
                    }
                    else
                    {
                        if (dto.referenceList.Count == 1)
                        {
                            referenceListCreated.Add(dto.referenceList[0]);
                            referenceListCreated.Add(referenceToAddList);

                            foreach (var item in referenceListCreated)
                            {
                                var firstItem = false;
                                ApiModel.Person.Person referenceToAdd = new ApiModel.Person.Person();
                                referenceToAdd.idPersonType = 3;
                                referenceToAdd.idPersonState = 1;
                                int idReferenceCreated = 0;
                                if (firstItem == false)
                                {
                                    idReferenceCreated = _unitOfWork.IPerson.Insert(referenceToAdd.Mapper(referenceToAdd, item));
                                }
                                else
                                {
                                    idReferenceCreated = _unitOfWork.IPerson.Insert(referenceToAdd);
                                }

                                PersonReference personReferenceCreated = new PersonReference();
                                personReferenceCreated.idClient = idPersonCreated;
                                personReferenceCreated.idReference = idReferenceCreated;
                                var idPersonReferenceCreated = _unitOfWork.IPersonReference.Insert(personReferenceCreated);

                                firstItem = true;
                            }
                        }

                        if (dto.referenceList.Count == 2)
                        {

                            foreach (var item in dto.referenceList)
                            {
                                ApiModel.Person.Person referenceToAdd = new ApiModel.Person.Person();
                                referenceToAdd.idPersonType = 3;
                                referenceToAdd.idPersonState = 1;

                                int idReferenceCreated = _unitOfWork.IPerson.Insert(referenceToAdd.Mapper(referenceToAdd, item));

                                PersonReference personReferenceCreated = new PersonReference();
                                personReferenceCreated.idClient = idPersonCreated;
                                personReferenceCreated.idReference = idReferenceCreated;
                                var idPersonReferenceCreated = _unitOfWork.IPersonReference.Insert(personReferenceCreated);
                            }
                        }
                    }

                   transaction.Complete();
                }

                return resultado;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool UpdatePerson(UpdatePersonFullRequestDTO dto)
        {
            try
            {
                bool response = false;
                using (var transaction = new TransactionScope())
                {
                    var updateClient = _unitOfWork.IPerson.Update(dto.client);
                    response = updateClient;
                    var updateExtraData = _unitOfWork.IPersonExtraData.Update(dto.extraClientData);
                    var updateLaborData = _unitOfWork.ILaborData.Update(dto.laborData);

                    ApiModel.Person.Person newSpouse = new ApiModel.Person.Person();
                    var updateSpouse = _unitOfWork.IPerson.Update(newSpouse.Mapper(newSpouse, dto.spouse.spouseData));
                    var updateSpouseLaborData = _unitOfWork.ILaborData.Update(dto.spouse.spouseLaborData);

                    foreach (var item in dto.referenceList)
                    {
                        ApiModel.Person.Person newReference = new ApiModel.Person.Person();
                        var updateReference = _unitOfWork.IPerson.Update(newReference.Mapper(newReference, item));
                    }

                    transaction.Complete();
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<ApiModel.Person.Person> GetList()
        {
            try
            {
                return _unitOfWork.IPerson.GetList().ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<PersonResponse> GetClientList()
        {
            try
            {
                List<PersonResponse> response = new List<PersonResponse>();

                response = _unitOfWork.IPerson.GetClientList();

                foreach (var item in response)
                {

                    int Years(DateTime start, DateTime end)
                    {
                        return (end.Year - start.Year - 1) +
                            (((end.Month > start.Month) ||
                            ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
                    }

                    if (item.dateOfBirth != null)
                    {
                        item.age = Years((DateTime)item.dateOfBirth, DateTime.Now);
                    }
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int ChangePersonState(int idPerson)
        {
            try
            {
                var person = _unitOfWork.IPerson.GetById(idPerson);
                int idPersonState = 0;
                //validamos su estado actual
                if (person.idPersonState == 1)
                {
                    idPersonState = 2;
                    _unitOfWork.IPerson.ChangePersonState(idPerson, idPersonState);
                }
                else
                {
                    idPersonState = 1;
                    _unitOfWork.IPerson.ChangePersonState(idPerson, idPersonState);
                }

                return idPersonState;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int AddToLoanList(List<ClientLoanRequestDTO> dto)
        {
            try
            {
                int response = 0;

                foreach(var item in dto)
                {
                    response = AddToLoan(item);
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int AddToLoan(ClientLoanRequestDTO dto)
        {
            try
            {
                ClientLoan obj = new ClientLoan();
                obj.clientLoan = dto.idClient.ToString() + dto.idLoan.ToString();
                _unitOfWork.IClientLoan.Insert(obj.Mapper(obj, dto));
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int DeleteClientFromLoan(int idClient, int idLoan)
        {
            try
            {
                return _unitOfWork.IClientLoan.DeleteClientLoanRegister(idClient, idLoan);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string CheckClientByDocumentNumber(string documentNumber)
        {
            try
            {
                var response = "";

                var checkClient = _unitOfWork.IPerson.CheckPersonByDocumentNumber(documentNumber);

                if (checkClient != null)
                {
                    response = checkClient.name + " " + checkClient.lastname;
                }
                else
                {
                    response = null;
                }

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PersonFullResponse GetFullInformation(int idPerson)
        {
            try
            {
                PersonFullResponse response = new PersonFullResponse();
                response.client = _unitOfWork.IPerson.GetById(idPerson);
                response.extraClientData = _unitOfWork.IPersonExtraData.GetPersonExtraDataByIdPerson(idPerson);
                response.laborData = _unitOfWork.ILaborData.GetLaborDataByIdPerson(idPerson);

                var spousePerson = _unitOfWork.ISpousePerson.GetSpousePerson(idPerson);

                SpouseFullResponse spouseResponse = new SpouseFullResponse();
                spouseResponse.spouseData = _unitOfWork.IPerson.GetReference(spousePerson.idSpouse);
                spouseResponse.spouseLaborData = _unitOfWork.ILaborData.GetLaborDataByIdPerson(spousePerson.idSpouse);

                response.spouse = spouseResponse;

                List<Reference> referenceToAdd = new List<Reference>();
                var personReference = _unitOfWork.IPersonReference.GetPersonReference(idPerson);
                foreach(var item in personReference)
                {
                    Reference newReference = new Reference();
                    newReference = _unitOfWork.IPerson.GetReference(item.idReference);

                    referenceToAdd.Add(newReference);
                }
                response.referenceList = referenceToAdd;
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<PersonResponse> GetClientByIdLoan(int idLoan)
        {
            try
            {
                return _unitOfWork.IPerson.GetClientsByIdLoan(idLoan);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UploadSentinelPdf(UploadPdfRequestDTO dto)
        {
            try
            {
                var user = _unitOfWork.IUsers.GetById(dto.idPerson);
                string nameFile = user.lastname + user.name + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                var response = _uploadFileLogic.UploadPdfToAzure(dto.files, nameFile);
                HistoricalSentinelReport sentinelReport = new HistoricalSentinelReport();
                sentinelReport.idClient = dto.idPerson;
                sentinelReport.uploadDate = DateTime.Now;
                sentinelReport.filePDF = response;
                _unitOfWork.IHistoricalSentinelReport.Insert(sentinelReport);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<HistoricalSentinelReport> GetHistoricalSentinelReportByIdPerson(int idPerson)
        {
            try
            {
                return _unitOfWork.IHistoricalSentinelReport.GetHistoricalSentinelReport(idPerson);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool DeleteSentinelReport(int idHistoricalDeleted)
        {
            try
            {
                HistoricalSentinelReport obj = new HistoricalSentinelReport();
                obj.idHistorical = idHistoricalDeleted;
                return _unitOfWork.IHistoricalSentinelReport.Delete(obj);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
