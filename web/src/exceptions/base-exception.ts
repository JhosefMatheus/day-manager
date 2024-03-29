import { AlertVariantEnum } from "@/enums";
import { z } from "zod";

export const BaseExceptionProps = z.object({
  message: z.string(),
  variant: z.nativeEnum(AlertVariantEnum),
});

export class BaseException extends Error {
  public message: string;
  public variant: AlertVariantEnum;

  constructor({ message, variant }: z.infer<typeof BaseExceptionProps>) {
    super(message);

    this.message = message;
    this.variant = variant;
  }

  public getMessage(): string {
    return this.message;
  }

  public getVariant(): AlertVariantEnum {
    return this.variant;
  }
}