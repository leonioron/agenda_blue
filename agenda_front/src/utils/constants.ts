export const AGENDA_API_URL = 'http://localhost:5172/api'

export const ERROR_MESSAGES = {
    INVALID_NAME: `Nome inválido! \n- não deve conter números ou caracteres especiais;\n- deve conter pelo menos uma letra;\n- deve ter no máximo 255 caracteres;`,
    INVALID_EMAIL: `E-mail inválido!; \n- não deve conter caracteres especiais execto '.' e '@';\n- deve ter no máximo 255 caracteres;`,
    INVALID_PHONE: `Telefone inválido! \n- deve conter apenas números;\n- deve ter no máximo 15 caracteres;`
}

export const REGEX = {
    VALID_NAME: /^[a-zA-Z\s]+$/,
    VALID_EMAIL: /^[^\s@]+@[^\s@]+\.[^\s@]+$/
}