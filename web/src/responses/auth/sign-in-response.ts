import { UserModel } from "@/models";
import { BaseResponse, BaseResponseProps } from "../base-response";

export interface SignInResponseProps extends BaseResponseProps {
  token: string;
  user: UserModel;
}

export class SignInResponse extends BaseResponse {
  public token: string;
  public user: UserModel;

  constructor({ message, variant, token, user }: SignInResponseProps) {
    super({ message, variant });

    this.token = token;
    this.user = user;
  }
}