resource "aws_sqs_queue" "user_updates_queue" {
  name = "user-updates-queue"
  receive_wait_time_seconds = 10
}

resource "aws_sqs_queue_policy" "queue_policy" {
  queue_url = "${aws_sqs_queue.user_updates_queue.id}"

  policy = <<POLICY
{
  "Version": "2012-10-17",
  "Id": "sqspolicy",
  "Statement": [
    {
      "Sid": "First",
      "Effect": "Allow",
      "Principal": "*",
      "Action":["sqs:ReceiveMessage", "sqs:SendMessage"],
      "Resource": "${aws_sqs_queue.user_updates_queue.arn}",
      "Condition": {
        "ArnEquals": {
          "aws:SourceArn": "${aws_sns_topic.user_updates.arn}"
        }
      }
    }
  ]
}
POLICY
}