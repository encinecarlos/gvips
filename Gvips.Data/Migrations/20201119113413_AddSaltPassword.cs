using Microsoft.EntityFrameworkCore.Migrations;

namespace Gvips.Data.Migrations
{
    public partial class AddSaltPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Posts_PostId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_SubscriptionPlan_PlanId",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Posts_PostId",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.RenameTable(
                name: "Subscription",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_PostId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_PlanId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_PostId",
                table: "Documents",
                newName: "IX_Documents_PostId");

            migrationBuilder.AddColumn<string>(
                name: "SaltPassword",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Posts_PostId",
                table: "Documents",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionPlan_PlanId",
                table: "Subscriptions",
                column: "PlanId",
                principalTable: "SubscriptionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Posts_PostId",
                table: "Subscriptions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Posts_PostId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionPlan_PlanId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Posts_PostId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SaltPassword",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "Subscription");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_PostId",
                table: "Subscription",
                newName: "IX_Subscription_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_PlanId",
                table: "Subscription",
                newName: "IX_Subscription_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_PostId",
                table: "Document",
                newName: "IX_Document_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Posts_PostId",
                table: "Document",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_SubscriptionPlan_PlanId",
                table: "Subscription",
                column: "PlanId",
                principalTable: "SubscriptionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Posts_PostId",
                table: "Subscription",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
