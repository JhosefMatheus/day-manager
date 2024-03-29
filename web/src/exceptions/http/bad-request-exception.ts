import { BaseHttpExceptionProps, BaseHttpException } from "./base-http-exception";
import { z } from "zod";

export const BadRequestExceptionProps = BaseHttpExceptionProps.extend({});

export class BadRequestException extends BaseHttpException {
  constructor({ message, variant }: z.infer<typeof BadRequestExceptionProps>) {
    super({ message, variant });
  }
}