// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;

    private Result(TValue? value)
    {
        _value = value;
        _error = default;
        this.IsError = false;
    }
    private Result(TError? error)
    {
        _value = default;
        _error = error;
        this.IsError = true;
    }

    public bool IsError { get; }

    public bool IsSuccess => !this.IsError;

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    public static implicit operator Result<TValue, TError>(TError error) => new(error);


    public TResult Match<TResult>(Func<TValue, TResult> success, Func<TError, TResult> error)
    {
        return this.IsError ? error(_error!) : success(_value!);
    }

    public TError? Error => _error;
    public TValue? Value => _value;

}
