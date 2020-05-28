import { createAsyncAction } from "typesafe-actions";
import { SubmitLoginPayload } from "./SubmitLoginPayload";

export const SUBMIT_LOGIN_REQUEST = "SUBMIT_LOGIN_REQUEST";
export const SUBMIT_LOGIN_SUCCESS = "SUBMIT_LOGIN_SUCCESS";
export const SUBMIT_LOGIN_FAILURE = "SUBMIT_LOGIN_FAILURE";

export const submitLoginAsync = createAsyncAction(
  SUBMIT_LOGIN_REQUEST,
  SUBMIT_LOGIN_SUCCESS,
  SUBMIT_LOGIN_FAILURE
)<SubmitLoginPayload, undefined, Error>();
