public static class ErrorMessages
{
    public const string Required = "O campo {0} é obrigatório.";
    public const string MaxLength = "O campo {0} deve ter apenas {1} caracteres.";
    public const string InvalidField = "{0} inválido.";
}

public static class MaximumLength
{
    public const int Fields = 255;
    public const int Phone = 15;
}

public static class Regex
{
    public const string ValidName = @"^[a-zA-Zà-úÀ-Ú' ]+$";
    public const string ValidPhone = @"^\d{1,15}$";
}

public static class Field
{
    public const string Name = "nome";
    public const string Phone = "telefone";
    public const string Email = "email";
}
