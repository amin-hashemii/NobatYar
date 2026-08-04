namespace Application.Configuration.Exceptions;

public record ErrorCode (int Id, string Name, string Desc);
public static class ApplicationErrors
{
    public static readonly ErrorCode InvalidData = new(1, "INVALID_DATA", "داده‌های ورودی معتبر نیستند.");
    public static readonly ErrorCode UserNotFound = new(2, "USER_NOT_FOUND", "کاربر مورد نظر یافت نشد.");
    public static readonly ErrorCode CategoryNotFound = new(7, "CATEGORY_NOT_FOUND", "دسته مورد نظر یافت نشد.");
    public static readonly ErrorCode KycFailed = new(3, "KYC_FAILED", "فرآیند احراز هویت با شکست مواجه شد.");
    public static readonly ErrorCode InvalidCredentials  = new(4, "KYC_FAILED", "نام کاربری یا رمز عبور اشتباه است.");
    public static readonly ErrorCode ProviderNotFound = new(5, "Provide_NOT_FOUND", "اراعه مورد نظر یافت نشد.");
    public static readonly ErrorCode ServiceNotFound = new(6, "Service_NOT_FOUND", "سرویس مورد نظر یافت نشد.");
}