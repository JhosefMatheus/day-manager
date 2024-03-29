import { BaseHttpException, BaseHttpExceptionProps } from "./base-http-exception";
import { z } from "zod";

export const UnauthorizedRequestExceptionProps = BaseHttpExceptionProps.extend({});

export class UnauthorizedRequestException extends BaseHttpException {
  constructor({ message, variant }: z.infer<typeof UnauthorizedRequestExceptionProps>) {
    super({ message, variant });
  }
}