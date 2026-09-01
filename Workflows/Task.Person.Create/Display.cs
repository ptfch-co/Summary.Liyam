namespace Summary.Liyam.Workflows.Task.Person.Create
{
    using Core.Workflows.Display;

    public class CreatePersonInLiyamDisplay :
        ActivityDisplayDriver<CreatePersonInLiyamTask, CreatePersonInLiyamViewModel>
    {
        protected override void EditActivity(
            CreatePersonInLiyamTask activity,
            CreatePersonInLiyamViewModel model)
        {
            model.Title = activity.Title;
            model.Group = activity.Group;
            model.Region = activity.Region;
            model.FirstName = activity.FirstName;
            model.LastName = activity.LastName;
            model.NationalCode = activity.NationalCode;
            model.EconomicCode = activity.EconomicCode;
            model.Address = activity.Address;
            model.Phone = activity.Phone;
            model.Mobile = activity.Mobile;
            model.Email = activity.Email;
            model.PostalCode = activity.PostalCode;
            model.City = activity.City;
            model.State = activity.State;
            model.Description = activity.Description;
        }

        protected override void UpdateActivity(
            CreatePersonInLiyamViewModel model,
            CreatePersonInLiyamTask activity)
        {
            activity.Title = model.Title;
            activity.Group = model.Group;
            activity.Region = model.Region;
            activity.FirstName = model.FirstName;
            activity.LastName = model.LastName;
            activity.NationalCode = model.NationalCode;
            activity.EconomicCode = model.EconomicCode;
            activity.Address = model.Address;
            activity.Phone = model.Phone;
            activity.Mobile = model.Mobile;
            activity.Email = model.Email;
            activity.PostalCode = model.PostalCode;
            activity.City = model.City;
            activity.State = model.State;
            activity.Description = model.Description;
        }
    }
}