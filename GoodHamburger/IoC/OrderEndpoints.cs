using GoodHamburger.DTOs;
using GoodHamburger.Exceptions;
using GoodHamburger.Handlers;
using GoodHamburger.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.IoC;

public static class OrderEndpoints
{

    public static void AddOrderEndpoints(this WebApplication app)
    {

        app.MapPost("/Order",
         Results<Created<OrderDTO>, BadRequest<string>, NotFound<string>, ProblemHttpResult> (IOrderService service, [FromBody] ComboDTO order) =>
         {
             try
             {
                 var handler = new SendOrder(service);
                 return TypedResults.Created("", handler.Handle(order));
             }
             catch (BusinessException ex)
             {
                 return TypedResults.BadRequest(ex.Message);

             }
             catch (NotFoundException nf)
             {
                 return TypedResults.NotFound(nf.Message);
             }
             catch (Exception e)
             {
                 return TypedResults.Problem(e.Message);
             }

         })
        .WithName("sendOrder")
        .WithDescription("Send an order and return the amount")
        .WithOpenApi();

        app.MapGet("/Orders", () =>
        {
            var handler = new ListOrders();
            return TypedResults.Ok(handler.Handle());
        })
        .WithName("listOrders")
        .WithDescription("List all orders")
        .WithOpenApi();

        app.MapPut("/Order/{orderId}",
        Results<Ok, BadRequest<string>, NotFound<string>, ProblemHttpResult> (IOrderService service, string orderId, [FromBody] ComboDTO order) =>
        {
            try
            {
                var handler = new UpdateOrder(service);
                handler.Handle(orderId, order);
                return TypedResults.Ok();
            }
            catch (BusinessException ex)
            {
                return TypedResults.BadRequest(ex.Message);

            }
            catch (NotFoundException nf)
            {
                return TypedResults.NotFound(nf.Message);
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message);
            }
        })
        .WithName("updateOrder")
        .WithDescription("Update an order and return the amount")
        .WithOpenApi();

        app.MapDelete("/Order/{orderId}", (string orderId) =>
        {
            var handler = new DeleteOrder();
            handler.Handle(orderId);
            return TypedResults.Ok();
        })
        .WithName("deleteOrder")
        .WithDescription("Delete an order")
        .WithOpenApi();
    }
}