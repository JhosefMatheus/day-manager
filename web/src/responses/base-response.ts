import { AlertVariantEnum } from "@/enums";

export interface BaseResponseProps {
  message: string;
  variant: AlertVariantEnum;
}

export class BaseResponse {
  public message: string;
  public variant: AlertVariantEnum;

  constructor({ message, variant }: BaseResponseProps) {
    this.message = message;
    this.variant = variant;
  }
}