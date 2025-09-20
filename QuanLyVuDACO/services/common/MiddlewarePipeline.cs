using System;
using System.Collections.Generic;
using System.Linq;

public class MiddlewarePipeline
{
    private readonly List<IMiddleware> _middlewares = new List<IMiddleware>();

    public MiddlewarePipeline Use(IMiddleware middleware)
    {
        _middlewares.Add(middleware);
        return this;
    }

    public void Execute(Action action)
    {
        Action next = action;
        foreach (var middleware in _middlewares.AsEnumerable().Reverse())
        {
            var current = next;
            next = () => middleware.Invoke(current);
        }
        next();
    }
}

public interface IMiddleware
{
    void Invoke(Action next);
}