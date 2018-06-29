import { ErrorContext } from './ErrorContext';

export class ErrorEventArgs {
	public CurrentObject: any ;
	public ErrorContext: ErrorContext ;

	public constructor(
		fields?: Partial<ErrorEventArgs>) {

		if (fields) {
			if (fields.ErrorContext) { fields.ErrorContext = new ErrorContext(fields.ErrorContext); }


			Object.assign(this, fields);
		}
	}
}
