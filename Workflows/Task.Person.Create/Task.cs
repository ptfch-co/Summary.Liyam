namespace Summary.Liyam.Workflows.Task.Person.Create
{
    using Core.Workflows;
    using Core.Workflows.Activities;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Models;
    using Microsoft.Extensions.Localization;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CreatePersonInLiyamTask : TaskActivity
    {
        private readonly IStringLocalizer<CreatePersonInLiyamTask> T;
        private readonly IPersonService _person;

        public CreatePersonInLiyamTask(IStringLocalizer<CreatePersonInLiyamTask> t,
            IPersonService person)
        {
            T = t;
            _person = person;
        }

        public override string Name => nameof(CreatePersonInLiyamTask);

        public override LocalizedString DisplayText => T[Liyam.Localize.DOfCreatePerson];

        public override LocalizedString Category => T[Liyam.Public.Category];

        public string Title
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string Group
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string Region
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string FirstName
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string LastName
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string NationalCode
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string EconomicCode
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string Address
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string Phone
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string Mobile
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string Email
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string PostalCode
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string City
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string State
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public string Description
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[Liyam.Workflows.Done]);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            var title = workflowContext.GetInputOrDefault(Title);
            var group = workflowContext.GetInputOrDefault(Group);
            var region = workflowContext.GetInputOrDefault(Region);
            var firstName = workflowContext.GetInputOrDefault(FirstName);
            var lastName = workflowContext.GetInputOrDefault(LastName);
            var nationalCode = workflowContext.GetInputOrDefault(NationalCode);
            var economicCode = workflowContext.GetInputOrDefault(EconomicCode);
            var address = workflowContext.GetInputOrDefault(Address);
            var phone = workflowContext.GetInputOrDefault(Phone);
            var mobile = workflowContext.GetInputOrDefault(Mobile);
            var email = workflowContext.GetInputOrDefault(Email);
            var postalCode = workflowContext.GetInputOrDefault(PostalCode);
            var city = workflowContext.GetInputOrDefault(City);
            var state = workflowContext.GetInputOrDefault(State);
            var description = workflowContext.GetInputOrDefault(Description);

            var groupId = await _person.GetDetailGroupIdByTitleAsync(group);
            var regionId = await _person.GetRegionIdByTitleAsync(region);
            var stateId = await _person.GetStateIdByTitleAsync(state);
            var cityId = await _person.GetCityIdByTitleAsync(city);

            await _person.CreatePersonAsync(
               title,
               groupId,
               regionId,
               firstName,
               lastName, nationalCode,
               economicCode,
               address,
               phone,
               mobile,
               email,
               postalCode,
               cityId,
               stateId,
               description
            );

            return Outcomes(Liyam.Workflows.Done);
        }
    }
}