resource "aws_cloudwatch_log_group" "sns-log-group" {
  name = "sns-log-group"
}

resource "aws_cloudwatch_log_stream" "sns-log-group-stream" {
  name           = "sns-log-group-stream"
  log_group_name = "${aws_cloudwatch_log_group.sns-log-group.name}"
}