import * as React from "react";

class ErrorAlert extends React.Component {
  render() {
    return (
      <div className="alert alert-danger" role="alert">
        {this.props.children}
      </div>
    );
  }
}

export default ErrorAlert;
