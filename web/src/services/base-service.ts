import { BadRequestException, NotFoundRequestException, ServerSideRequestException, UnauthorizedRequestException } from "@/exceptions";
import { BaseHttpException } from "@/exceptions/http/base-http-exception";
import { BaseResponse } from "@/responses/base-response";

export class BaseService {
  protected static async handleApiResponse<T extends BaseResponse>(response: Response): Promise<T> {
    try {
      const responseStatus: number = response.status;
      const responseBody: T = await response.json();


      switch (responseStatus) {
        case 200:
          return responseBody;

        case 400:
          throw new BadRequestException({
            message: responseBody.message,
            variant: responseBody.variant,
          });

        case 401:
          throw new UnauthorizedRequestException({
            message: responseBody.message,
            variant: responseBody.variant,
          });

        case 404:
          throw new NotFoundRequestException({
            message: responseBody.message,
            variant: responseBody.variant,
          });

        case 500:
          throw new ServerSideRequestException({
            message: responseBody.message,
            variant: responseBody.variant,
          });

        default:
          throw new BaseHttpException({
            message: responseBody.message,
            variant: responseBody.variant,
          });
      }
    } catch (error: any) {
      throw error;
    }
  }
}