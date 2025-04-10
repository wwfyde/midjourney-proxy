namespace Midjourney.Infrastructure.Models;

using System;

public readonly struct ErrorCode
{
    public string Code { get; }
    public string Message { get; }

    private ErrorCode(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public override string ToString() => $"{Code}: {Message}";

    // 通用错误
    public static readonly ErrorCode Error = new ErrorCode("0001", "一般错误");
    public static readonly ErrorCode UnknownRequest = new ErrorCode("0002", "未知请求");
    
    // 系统错误
    public static readonly ErrorCode SysInternalError = new ErrorCode("SYS-1001", "系统内部错误");
    public static readonly ErrorCode SysParamError = new ErrorCode("SYS-1002", "系统参数错误");

    // 用户模块
    public static readonly ErrorCode UserNotFound = new ErrorCode("2001", "用户不存在");
    public static readonly ErrorCode UserQuotaLimited = new ErrorCode("USER-2001", "用户配额不足");

    // MJ模块
    public static readonly ErrorCode MjAccountError = new ErrorCode("MJ-3001", "MJ无可用账号");
    public static readonly ErrorCode MjAccountBaned = new ErrorCode("MJ-3002", "MJ账号被封禁");
    public static readonly ErrorCode MjActionError = new ErrorCode("MJ-3003", "MJ动作执行失败");
    public static readonly ErrorCode MjImageUploadError = new ErrorCode("MJ-3004", "MJ上传图片失败");
    
}