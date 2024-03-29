import { BaseHttpExceptionProps, BaseHttpException } from "./base-http-exception";
import { z } from "zod";

export const NotFoundRequestExceptionProps = BaseHttpExceptionProps.extend({});

export class NotFoundRequestException extends BaseHttpException {
  constructor({ message, variant }: z.infer<typeof NotFoundRequestExceptionProps>) {
    super({ message, variant });
  }
}