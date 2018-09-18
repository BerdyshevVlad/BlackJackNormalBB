using BlackJack.DataAccess.Context.MVC;
using BlackJack.Entities;
using System;
using System.Web.Mvc;

namespace ExceptionLoggers
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
    {
        ExceptionDetail exceptionDetail = new ExceptionDetail()
        {
            ExceptionMessage = filterContext.Exception.Message,
            StackTrace = filterContext.Exception.StackTrace,
            ControllerName = filterContext.RouteData.Values["controller"].ToString(),
            ActionName = filterContext.RouteData.Values["action"].ToString(),
            Date = DateTime.Now
        };

        using (BlackJackContext db = new BlackJackContext())
        {
            db.ExceptionDetails.Add(exceptionDetail);
            db.SaveChanges();
        }

        filterContext.ExceptionHandled = true;
    }
}
}