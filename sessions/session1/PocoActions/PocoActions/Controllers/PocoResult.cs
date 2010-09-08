namespace PocoActions.Controllers {
    using System.Web.Mvc;

    public class PocoResult : ActionResult
    {
        public PocoResult(object pocoModel)
        {
            Model = pocoModel;
        }

        public object Model { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var jsonResult = new JsonResult
                             {
                                 JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                                 Data = Model
                             };

            jsonResult.ExecuteResult(context);
        }
    }
}