﻿using System.Collections.Generic;
using System.Linq;

using Cerseil.Commands;

namespace Cerseil.Services
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult()
        {
            ValidationResultList = new List<ICommandValidationResult>();
            CommandResultList = new List<ICommandResult>();
        }

        public ServiceResult(ActionResultList actionResults) : this()
        {
            ActionResults = actionResults;
            AddValidationResults(ActionResults.ValidationResults.ToList());
            AddCommandResults(ActionResults.CommandResults.ToList());
        }

        public IEnumerable<ICommandValidationResult> ValidationResults
        {
            get { return ValidationResultList; }
        }

        public IEnumerable<ICommandResult> CommandResults
        {
            get { return CommandResultList; }
        }

        public string ReturnMessage { get; private set; }

        public ActionResultList ActionResults { get; private set; }

        public bool Success
        {
            get
            {
                var validarionsSuccess = false;
                var commandsSuccess = true;

                if (ValidationResults != null)
                {
                    validarionsSuccess = !ValidationResults.Any();
                }

                if (CommandResults != null)
                {
                    foreach (var commandResult in CommandResults)
                    {
                        if (commandResult != null)
                        {
                            commandsSuccess = commandsSuccess && commandResult.Success;
                        }
                    }
                }

                return validarionsSuccess && commandsSuccess;
            }
        }

        protected List<ICommandValidationResult> ValidationResultList { get; private set; }

        protected List<ICommandResult> CommandResultList { get; private set; }

        public void SetReturnMessage(string returnMessage)
        {
            ReturnMessage = returnMessage;
        }

        public void AddValidationResult(ICommandValidationResult validationResult)
        {
            ValidationResultList.Add(validationResult);
        }

        public void AddValidationResults(IEnumerable<ICommandValidationResult> validationResults)
        {
            if (validationResults == null)
            {
                return;
            }

            ValidationResultList.AddRange(validationResults);
        }

        public void AddCommandResult(ICommandResult commandResult)
        {
            CommandResultList.Add(commandResult);
        }

        public void AddCommandResults(IEnumerable<ICommandResult> commandResults)
        {
            if (commandResults == null)
            {
                return;
            }

            CommandResultList.AddRange(commandResults);
        }


        public IEnumerable<string> GetErrorMessages()
        {
            return ValidationResults.Select(validationResult => validationResult.ErrorMessage).ToList();
        }

        public string GetFirstErrorMessage()
        {
            var errorMessage = string.Empty;

            if (ValidationResults.Any())
            {
                var commandValidationResult = ValidationResults.FirstOrDefault();
                if (commandValidationResult != null)
                {
                    errorMessage = commandValidationResult.ErrorMessage;
                }
            }

            return errorMessage;
        }
    }

    public class ServiceResult<TReturnResult> : ServiceResult, IServiceResult, IServiceResult<TReturnResult>
    {
        public ServiceResult() : base()
        {
        }

        public ServiceResult(ActionResultList actionResults) : base(actionResults)
        {
        }

        public TReturnResult ReturnResult { get; private set; }

        public void SetReturnResult(TReturnResult returnResult)
        {
            ReturnResult = returnResult;
        }
    }
}
