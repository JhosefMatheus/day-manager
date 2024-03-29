import { z } from "zod";
import { BaseException, BaseExceptionProps } from "./base-exception";

export const EmptyFormFieldExceptionProps = BaseExceptionProps.extend({});

export class EmptyFormFieldException extends BaseException {
  constructor({ message, variant }: z.infer<typeof EmptyFormFieldExceptionProps>) {
    super({ message, variant });
  }
}