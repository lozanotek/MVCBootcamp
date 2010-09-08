namespace PocoActions.Controllers {
    using System.Web.Mvc;

    public class PocoActionInvoker : ControllerActionInvoker
    {
        protected override ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
        {
            if (!(actionReturnValue is ActionResult))
            {
                controllerContext.Controller.ViewData.Model = actionReturnValue;
                return new PocoResult(actionReturnValue);
            }

            return base.CreateActionResult(controllerContext, actionDescriptor, actionReturnValue);
        }
    }
}