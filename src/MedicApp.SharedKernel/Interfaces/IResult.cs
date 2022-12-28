﻿namespace MedicApp.SharedKernel.Interfaces;

public interface IResult
{
    bool HasError { get; }

    string Message { get; }
}
