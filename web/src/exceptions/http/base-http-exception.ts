import { BaseExceptionProps, BaseException } from "../base-exception";
import { z } from "zod";

export const BaseHttpExceptionProps = BaseExceptionProps.extend({});

export class BaseHttpException extends BaseException {
  constructor({ message, variant }: z.infer<typeof BaseHttpExceptionProps>) {
    super({ message, variant });
  }
}