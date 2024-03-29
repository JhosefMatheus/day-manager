import { SignInResponse, SignInResponseProps } from "@/responses";
import { BaseService } from "./base-service";
import { EmptyFormFieldException } from "@/exceptions";
import { AlertVariantEnum } from "@/enums";
import { ApiConfig } from "@/config";

export class AuthService extends BaseService {
  public static async signIn(login: string, password: string): Promise<SignInResponse> {
    try {
      const loginEmpty: boolean = login.length === 0;
      const passwordEmpty: boolean = password.length === 0;

      if (loginEmpty || passwordEmpty) {
        throw new EmptyFormFieldException({
          message: "Preencha todos os campos obrigatórios.",
          variant: AlertVariantEnum.WARNING,
        });
      }

      const response: Response = await fetch(`${ApiConfig.API_URL}/auth/sign-in`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Accept": "application/json",
        },
        body: JSON.stringify({ login, password }),
      });

      const responseBody: SignInResponse = await super.handleApiResponse<SignInResponse>(response);

      return responseBody;
    } catch (error: any) {
      throw error;
    }
  }
}