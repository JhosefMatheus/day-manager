import { BaseHttpExceptionProps, BaseHttpException } from "./base-http-exception";
import { z } from "zod";

export const ServerSideRequestExceptionProps = BaseHttpExceptionProps.extend({});

export class ServerSideRequestException extends BaseHttpException {
  constructor({ message, variant }: z.infer<typeof ServerSideRequestExceptionProps>) {
    super({ message, variant });
  }
}